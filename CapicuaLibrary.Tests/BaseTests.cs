using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Solution
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
        public void TestSimpleEncodeRun()
        {
            // Services
            var mailService = new MailService();

            List<Service> services = new List<Service>();
            services.Add(mailService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));
            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(1));
        }

        [Test]
        public void TestSimpleUnsubscribe()
        {
            // Services
            var mailService = new MailService();

            List<Service> services = new List<Service>();
            services.Add(mailService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));

            // Run with empty services list
            runner.UnsubscribeService(mailService);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));
            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestSeveralServices()
        {
            // Services
            var mailService = new MailService();
            var messageService = new MessageService();

            List<Service> services = new List<Service>();
            services.Add(mailService);
            services.Add(messageService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));
            Assert.That(messageService.getMessages(), Is.EqualTo(1));

            // Run flow
            runner.UnsubscribeService(mailService);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestSeveralServicesTwiceRun()
        {
            // Services
            var mailService = new MailService();
            var messageService = new MessageService();

            List<Service> services = new List<Service>();
            services.Add(mailService);
            services.Add(messageService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));
            Assert.That(messageService.getMessages(), Is.EqualTo(1));

            // Run flow another time
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(2));
            Assert.That(messageService.getMessages(), Is.EqualTo(2));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestThreeServices()
        {
            // Services
            var mailService = new MailService();
            var messageService = new MessageService();
            var browserNotificationService = new BrowserNotificationService();

            List<Service> services = new List<Service>();
            services.Add(mailService);
            services.Add(messageService);
            services.Add(browserNotificationService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));
            Assert.That(messageService.getMessages(), Is.EqualTo(1));
            Assert.That(browserNotificationService.getNotifications(), Is.EqualTo(1));

            // Run flow another time
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(2));
            Assert.That(messageService.getMessages(), Is.EqualTo(2));
            Assert.That(browserNotificationService.getNotifications(), Is.EqualTo(2));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestServiceSubscribeAndUnsubscribe()
        {
            // Services
            var mailService = new MailService();

            List<Service> services = new List<Service>();
            services.Add(mailService);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));

            // Run flow another time
            runner.UnsubscribeService(mailService);
            runner.SubscribeService(mailService);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(2));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestEmptyServiceList()
        {
            // Services
            var mailService = new MailService();

            List<Service> services = new List<Service>();

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(0));

            // Run flow another time
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(0));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestEmptyServiceListWithSubcription()
        {
            // Services
            var mailService = new MailService();

            List<Service> services = new List<Service>();

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(0));

            // Run flow another time
            runner.SubscribeService(mailService);
            runner.Encode();
            Assert.That(mailService.getSentEmail(), Is.EqualTo(1));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }

        [Test]
        public void TestServicesOfSameType()
        {
            // Services
            var mailService1 = new MailService();
            var mailService2 = new MailService();
            var mailService3 = new MailService();

            List<Service> services = new List<Service>();
            services.Add(mailService1);
            services.Add(mailService2);
            services.Add(mailService3);

            // Run flow
            var videoEncoder = new NotifyingVideoEncoder();
            Runner runner = new Runner(videoEncoder, services);
            runner.Encode();
            Assert.That(mailService1.getSentEmail(), Is.EqualTo(1));
            Assert.That(mailService2.getSentEmail(), Is.EqualTo(1));
            Assert.That(mailService3.getSentEmail(), Is.EqualTo(1));

            // Run flow another time
            runner.Encode();
            Assert.That(mailService1.getSentEmail(), Is.EqualTo(2));
            Assert.That(mailService2.getSentEmail(), Is.EqualTo(2));
            Assert.That(mailService3.getSentEmail(), Is.EqualTo(2));

            Assert.That(videoEncoder.getEncodedVideosCount(), Is.EqualTo(2));
        }
    }
}
