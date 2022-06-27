using System;
using System.Collections.Generic;

namespace Solution
{
    public class Runner
    {
        private NotifyingVideoEncoder videoEncoder;
        private event Action subscriber;

        public Runner(NotifyingVideoEncoder videoEncoder, List<Service> services)
        {
            this.videoEncoder = videoEncoder;
            foreach (var service in services)
            {
                SubscribeService(service);
            }
        }

        public void Encode()
        {
            videoEncoder.encodingFinishedEmitter += OnVideoEncoded;
            videoEncoder.EncodeVideo();
        }

        public void SubscribeService(Service item)
        {
            subscriber += item.OnVideoEncoded;
        }

        public void UnsubscribeService(Service item)
        {
            subscriber -= item.OnVideoEncoded;
        }

        private void OnVideoEncoded()
        {
            subscriber?.Invoke();
            videoEncoder.encodingFinishedEmitter -= OnVideoEncoded;
        }
    }
}
