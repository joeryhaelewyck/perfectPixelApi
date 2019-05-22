﻿using System.Collections.Generic;
using perfectPixelApi.DTOs;

namespace perfectPixelApi.Models
{
    public interface ISubmittedImageRepository
    {
        
        SubmittedImage GetImageById(int id);
        SubmittedImage GetImageByHighScoreByMonth(byte month);
        SubmittedImage GetImageByVoterByMonth(string mail, byte month);
        SubmittedImage ApplyPatch(SubmittedImage submittedImage, ImagePatchDTO imagePatch);
        IEnumerable<SubmittedImage> GetImagesByName(string name);
        IEnumerable<SubmittedImage> GetAll();
        IEnumerable<SubmittedImage> GetImagesByMonth(byte month);
        IEnumerable<SubmittedImage> GetImagesByVoter(string mail);

        int GetNewID();
        void Add(SubmittedImage image);
        void Delete(SubmittedImage image);
        void Update(SubmittedImage image);
        void SaveChanges();
        
    }
}
