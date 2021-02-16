using SportApp.Domain.BaseObjects;
using System.Collections.Generic;

namespace SportApp.Domain
{
    public class VideoUrl : ValueObject
    {
        public VideoUrl(string url, VideoService videoService)
        {
            Url = url;
            VideoService = videoService;
        }

        public string Url { get; private set; }
        public VideoService VideoService { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Url;
            yield return (int)this.VideoService;
        }
    }
}