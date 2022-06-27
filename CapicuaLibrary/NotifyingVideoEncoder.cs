using System;
using System.Collections.Generic;

namespace Solution
{
    public class NotifyingVideoEncoder : VideoEncoder
    {
        public event Action encodingFinishedEmitter;

        protected override void OnEncodingFinished()
        {
            encodingFinishedEmitter?.Invoke();
        }
    }
}
