using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaMan.Core.Domain;
using PizzaMan.DATA.Infrastructure;
using PizzaMan.Core.Repository;
using PizzaMan.Core.Infrastructure;
using PizzaMan.Core.Models;
using AutoMapper;
using PizzaMan.API.Infrastructure;

namespace PizzaMan.API.Controllers
{
    [Authorize]
    public class ReviewsController : BaseApiController
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IReviewRepository reviewRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(userRepository)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }
        // GET: api/Reviews
        public IEnumerable<ReviewModel> GetReviews()
        {
            return Mapper.Map<IEnumerable<ReviewModel>>(_reviewRepository.GetAll());
        }

        // GET: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult GetReview(int id)
        {
            Review review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ReviewModel>(review));
        }

        // GET: api/Review/Pizzeria
        [Route("api/reviews/pizzeriaId={id}")]
        public IEnumerable<ReviewModel> GetReviewsByPizzeria(int id)
        {
            return Mapper.Map<IEnumerable<ReviewModel>>(_reviewRepository.GetWhere(r => r.PizzeriaId == id));
        }

        // GET: api/Review/Pizzeria
        [Route("api/reviews/latest")]
        public IHttpActionResult GetLatestReview()
        {
            Review latestReview = _reviewRepository.GetAll().OrderBy(r => r.ReviewId).Last();

            return Ok(Mapper.Map<ReviewModel>(latestReview));
        }



        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, ReviewModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            var dbReview = _reviewRepository.GetById(id);
            dbReview.Update(review);
            _reviewRepository.Update(dbReview);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(ReviewModel review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbReview = new Review(review);

            dbReview.User = CurrentUser;

            _reviewRepository.Add(dbReview);
            _unitOfWork.Commit();
            review.ReviewId = dbReview.ReviewId;


            return CreatedAtRoute("DefaultApi", new { id = review.ReviewId }, review);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult DeleteReview(int id)
        {
            Review review =_reviewRepository.GetById(id);

            if (review == null)
            {
                return NotFound();
            }

            _reviewRepository.Delete(review);
            _unitOfWork.Commit();

            return Ok(review);
        }

     
        private bool ReviewExists(int id)
        {
            return _reviewRepository.Any(e => e.ReviewId == id);
        }
    }
}