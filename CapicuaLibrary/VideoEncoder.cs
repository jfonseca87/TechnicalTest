using System;
using System.Collections.Generic;

namespace Solution
{
    public abstract class VideoEncoder
    {
        private int encodedVideosCount;

        public VideoEncoder()
        {
            encodedVideosCount = 0;
        }

        public void EncodeVideo()
        {
            encodedVideosCount++;
            OnEncodingFinished();
        }

        public int getEncodedVideosCount()
        {
            return encodedVideosCount;
        }

        protected abstract void OnEncodingFinished();
    }
}
