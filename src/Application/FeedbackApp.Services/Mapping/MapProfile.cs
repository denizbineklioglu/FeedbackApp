using AutoMapper;
using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.DataTransferObjects.Responses;
using FeedbackApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateFeedBackRequest,FeedBack>();
            CreateMap<UpdateFeedBackRequest,FeedBack>();
            CreateMap<FeedBack, FeedBackListResponse>();
            //CreateMap<User, UserLoginRequest>();
            //CreateMap<User, UserRegisterRequest>();
            CreateMap<UserLoginRequest, User>();
            CreateMap<UserRegisterRequest, User>();
        }
    }
}
