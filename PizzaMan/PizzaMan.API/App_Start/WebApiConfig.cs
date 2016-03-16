using AutoMapper;
using PizzaMan.Core.Domain;
using PizzaMan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PizzaMan.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            CreateMaps();
        }
        public static void CreateMaps()
        {
            Mapper.CreateMap<Photo, PhotoModel>();
            Mapper.CreateMap<User, UserModel.Profile>();
            Mapper.CreateMap<Pizzeria, PizzeriaModel>();
            Mapper.CreateMap<Review, ReviewModel>();
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<Aspect, AspectModel>();
            Mapper.CreateMap<AspectRating, AspectRatingModel>();
        }
    }
}
