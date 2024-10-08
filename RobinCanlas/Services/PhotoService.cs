﻿using CloudinaryDotNet;
using Dapper;
using Newtonsoft.Json.Linq;
using RobinCanlas.Models;
using System.Collections.Generic;

namespace RobinCanlas.Services
{
    public class PhotoService(IFlickrService flickrService, ICloudinaryService cloudinaryService, IDbService dbService) : IPhotoService
    {
        private readonly IFlickrService _flickrService = flickrService;
        private readonly ICloudinaryService _cloudinaryService = cloudinaryService;
        private readonly IDbService _dbService = dbService;

        public async Task<List<GetAllFlickr>> GetPhotos()
        {
            var photos = await _dbService.GetAll<GetAllFlickr>("SELECT * FROM photo", new { });
            return photos;
        }

        public async Task<List<GetAllFlickrApi>> GetFlickrPhotos()
        {
            var photos = await _flickrService.GetPhotos();
            return photos;
        }

        public async Task<List<GetAllCloudinaryApi>> GetCloudinaryPhotos()
        {
            var photos = await _cloudinaryService.GetPhotos();
            return photos;
        }

        public async Task<int> DeleteAllPhotos()
        {
            var rowsAffected = await _dbService.EditData("TRUNCATE photo RESTART IDENTITY", new { });
            return rowsAffected;
        }
        public async Task<int> InsertFlickrPhotos()
        {
            List<GetAllFlickr> photos = _flickrService.ConstructFlickrPhotos(await GetFlickrPhotos());
            int rowsAffected = 0;

            foreach (var photo in photos)
            {
                DynamicParameters parameters = new();
                parameters.Add("p_index", photo.Index);
                parameters.Add("p_thumbnail", photo.Thumbnail);
                parameters.Add("p_url", photo.Url);
                parameters.Add("p_src", photo.Src);
                parameters.Add("p_raw", photo.Raw);
                parameters.Add("p_original", photo.Original);

                rowsAffected += await _dbService.ExecuteStoredProcedure(
                    "insertphoto",
                    parameters
                );

                //rowsAffected += await _dbService.EditData(
                //    "INSERT INTO photo (index, thumbnail, url, src, raw, original) VALUES (@index, @thumbnail, @url, @src, @raw, @original)",
                //    new { index = photo.Index, thumbnail = photo.Thumbnail, url = photo.Url, src = photo.Src, raw = photo.Raw, original = photo.Original }
                //);
            }

            return rowsAffected;
        }

    }
}
