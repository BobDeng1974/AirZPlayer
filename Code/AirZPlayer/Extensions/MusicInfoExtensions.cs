using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirZPlayer
{
    internal static class MusicInfoExtension
    {
        public static MusicInfoViewModel ToVM(this MusicInfo baseInfo)
        {
            return new MusicInfoViewModel()
            {
                Id = baseInfo.Id,
                Path = baseInfo.Path,
                Title = baseInfo.Title,
                Argist = baseInfo.Argist,
                Album = baseInfo.Album,
                Year = baseInfo.Year,
                Comment = baseInfo.Comment,
                Track = baseInfo.Track,
                Genre = baseInfo.Genre
            };
        }
        public static MusicInfoViewModel CopyBase(this MusicInfoViewModel musicInfoVM, MusicInfo baseInfo)
        {
            musicInfoVM.Id = baseInfo.Id;
            musicInfoVM.Path = baseInfo.Path;
            musicInfoVM.Title = baseInfo.Title;
            musicInfoVM.Argist = baseInfo.Argist;
            musicInfoVM.Album = baseInfo.Album;
            musicInfoVM.Year = baseInfo.Year;
            musicInfoVM.Comment = baseInfo.Comment;
            musicInfoVM.Track = baseInfo.Track;
            musicInfoVM.Genre = baseInfo.Genre;
            return musicInfoVM;
        }
    }
}
