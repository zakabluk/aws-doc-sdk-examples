 
//snippet-sourcedescription:[<<FILENAME>> demonstrates how to ...]
//snippet-keyword:[dotnet]
//snippet-keyword:[.NET]
//snippet-keyword:[Code Sample]
//snippet-service:[<<ADD SERVICE>>]
//snippet-sourcetype:[<<snippet or full-example>>]
//snippet-sourcedate:[]
//snippet-sourceauthor:[AWS]


﻿using System;
using Amazon.Polly;
using Amazon.Polly.Model;

namespace PollySamples1
{
    class DescribeVoicesSample
    {
        public static void DescribeVoices()
        {
            var client = new AmazonPollyClient();

            var allVoicesRequest = new DescribeVoicesRequest();
            var enUsVoicesRequest = new DescribeVoicesRequest()
            {
                LanguageCode = "en-US"
            };

            try
            {
                String nextToken;
                do
                {
                    var allVoicesResponse = client.DescribeVoices(allVoicesRequest);
                    nextToken = allVoicesResponse.NextToken;
                    allVoicesRequest.NextToken = nextToken;

                    Console.WriteLine("All voices: ");
                    foreach (var voice in allVoicesResponse.Voices)
                        Console.WriteLine(" Name: {0}, Gender: {1}, LanguageName: {2}", voice.Name,
                            voice.Gender, voice.LanguageName);
                } while (nextToken != null);

                do
                {
                    var enUsVoicesResponse = client.DescribeVoices(enUsVoicesRequest);
                    nextToken = enUsVoicesResponse.NextToken;
                    enUsVoicesRequest.NextToken = nextToken;

                    Console.WriteLine("en-US voices: ");
                    foreach (var voice in enUsVoicesResponse.Voices)
                        Console.WriteLine(" Name: {0}, Gender: {1}, LanguageName: {2}", voice.Name,
                            voice.Gender, voice.LanguageName);
                } while (nextToken != null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
        }
    }
}
