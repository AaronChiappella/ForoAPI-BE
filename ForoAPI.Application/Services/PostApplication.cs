using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using ForoAPI.Application.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForoAPI.Domain.Entities;
using AutoMapper;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using Utilities.Statics;

namespace ForoAPI.Application.Services
{
    public class PostApplication : IPostApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PostResDto>> Create(PostCreateDto postReqDto)
        {
            var response = new BaseResponse<PostResDto>();

            // Busca el usuario por el email proporcionado
            var author = await _unitOfWork.Users.GetByEmail(postReqDto.AuthorEmail);
            if (author == null)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "Author not found.";
                return response;
            }

            var post = _mapper.Map<Post>(postReqDto); // Mapea DTO a objeto
            var createdPost = await _unitOfWork.Posts.Add(post, author);

            if (createdPost is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<PostResDto>(createdPost);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Post could not be created.";
            }

            return response;
        }

        public async Task<BaseResponse<PostResDto>> Delete(int id)
        {
            var response = new BaseResponse<PostResDto>();

            // Retrieve the post by id
            var post = await _unitOfWork.Posts.GetById(id);

            if (post != null)
            {
               var deletedPost = await _unitOfWork.Posts.Delete(post);
                response.IsSuccess = true;
                response.Data = _mapper.Map<PostResDto>(deletedPost);
                response.Message = "Post deleted successfully.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Post not found.";
            }

            return response;
        }

        public async Task<BaseResponse<PostResDto>> Edit(PostReqDto postReqDto)
        {
            var response = new BaseResponse<PostResDto>();



            // Retrieve the post to be updated
            var existingPost = await _unitOfWork.Posts.GetById(postReqDto.Id);

            if (existingPost != null)
            {
                // Map updated values to the existing post entity
                _mapper.Map(postReqDto, existingPost);

                // Update the post in the repository
                await _unitOfWork.Posts.Edit(existingPost);

                response.IsSuccess = true;
                response.Data = _mapper.Map<PostResDto>(existingPost);
                response.Message = "Post updated successfully.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Post not found.";
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<PostResDto>>> GetAll()
        {
            var response = new BaseResponse<IEnumerable<PostResDto>>();

            // Retrieve all posts from the repository
            var posts = await _unitOfWork.Posts.GetAll();

            if (posts.Items != null && posts.Items.Any())
            {
                response.IsSuccess = true;
                // Map the list of posts to a collection of PostResDto
                response.Data = _mapper.Map<IEnumerable<PostResDto>>(posts.Items);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }

            return response;
        }

    }
}

        