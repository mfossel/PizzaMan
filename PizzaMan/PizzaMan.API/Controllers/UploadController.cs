using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PizzaMan.API.Infrastructure;
using PizzaMan.Core.Infrastructure;
using PizzaMan.Core.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace PizzaMan.API.Controllers
{
    public class BlobStorageMultipartStreamProvider : MultipartStreamProvider
    {
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            Stream stream = null;
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {
                if (!String.IsNullOrWhiteSpace(contentDisposition.FileName))
                {
                    string connectionString = ConfigurationManager.AppSettings["CloudStorageConnectionString"];
                    string containerName = ConfigurationManager.AppSettings["PizzeriaPhotoContainerName"];
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(contentDisposition.FileName);
                    stream = blob.OpenWrite();
 
                }
            }
            return stream;
        }

    }

    public class ImageUploadController : BaseApiController
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageUploadController(IPhotoRepository photoRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }




        [Route("api/upload/pizzeriaPhoto/{pizzeriaId}")]
        public async Task<HttpResponseMessage> UploadPizzeriaPhoto(int pizzeriaId)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                MultipartStreamProvider provider = new BlobStorageMultipartStreamProvider();

                
                await Request.Content.ReadAsMultipartAsync(provider);

                string containerURI = ConfigurationManager.AppSettings["ContainerURI"];

                var filename = provider.Contents[0].Headers.ContentDisposition.FileName;


                var photo = new Core.Domain.Photo();

                photo.PizzeriaId = pizzeriaId;
                photo.PhotoURL = containerURI + filename;
                photo.User = CurrentUser;
                _photoRepository.Add(photo);
                _unitOfWork.Commit();


            }

            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

                  

        



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }



   
    }


