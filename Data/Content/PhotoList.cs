using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class PhotosList
    {
        public static List<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo
                {
                    Id = Guid.Parse("790a30b7-8495-4a7e-a462-ab6cc1ebbe47"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    Source = "https://images.unsplash.com/flagged/photo-1566127992631-137a642a90f4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&w=1000&q=80"
                },
                new Photo
                {
                    Id = Guid.Parse("d04e9161-76b4-4f61-9b86-49763b1909f8"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    Source = "https://img.i-scmp.com/cdn-cgi/image/fit=contain,width=1098,format=auto/sites/default/files/styles/1200x800/public/d8/images/canvas/2022/02/15/6e8c06d1-a685-4242-ae53-f668717186d3_dceb3cfd.jpg?itok=1gvwtf1t&v=1644930191"
                },
                new Photo
                {
                    Id = Guid.Parse("e21aadbe-e525-48a3-98e1-370c5b8d7673"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    Source = "https://prod.static9.net.au/fs/a79a7806-d006-4ec6-bdbe-46b98e4888b7"
                },
                new Photo
                {
                    Id = Guid.Parse("80ed717d-5f15-43cc-994e-c1e2ca24dc2f"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    Source = "https://www.treehugger.com/thmb/kaA2K_9wVzTbPIyCRm3-oZuy6k0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/horse.primary-e9a47e1c486c4fb7bf729e05b59cf0df.jpg"
                },
                new Photo
                {
                    Id = Guid.Parse("0bce6af2-bf8d-403c-97ca-398c30c51372"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    Source = "http://www.chovzvirat.cz/images/zvirata/quarter-horse_sfm38qb.jpg"
                },
                new Photo
                {
                    Id = Guid.Parse("c72fbce6-7b4d-4214-b417-10754b6f2ae0"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    Source = "https://media.gq.com/photos/56e71c0b14cbe0637b261d7f/1:1/w_1696,h_1696,c_limit/horseinsuit2.jpg"
                },
                new Photo
                {
                    Id = Guid.Parse("0878806b-9b12-4eb1-ab8f-d6640de09a41"),
                    AnimalId = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
                    Source = "https://i.guim.co.uk/img/media/fe1e34da640c5c56ed16f76ce6f994fa9343d09d/0_174_3408_2046/master/3408.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=0d3f33fb6aa6e0154b7713a00454c83d"
                },
                new Photo
                {
                    Id = Guid.Parse("f108362b-8f73-4859-9ea5-737f0e1e00a1"),
                    AnimalId = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
                    Source = "https://ichef.bbci.co.uk/news/976/cpsprodpb/17638/production/_124800859_gettyimages-817514614.jpg"
                },
                new Photo
                {
                    Id = Guid.Parse("d218258a-24d1-4c5a-8062-7739c300c870"),
                    AnimalId = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
                    Source = "https://post.healthline.com/wp-content/uploads/2020/08/3180-Pug_green_grass-732x549-thumbnail-732x549.jpg"
                },
                new Photo
                {
                    Id = Guid.Parse("a7496b92-bdef-4e1e-bf36-f70b612fe9df"),
                    AnimalId = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
                    Source = "https://www.scotsman.com/webimg/b25lY21zOjViZjVjYjc0LTgwZDctNGE4Zi1iNWZiLTE1MDA3YzAyNzJjYTowNWY3YWEwMy04MTAxLTRmMWEtOTU3Ny1kZTk0ODJjNGJkNjc=.jpg?width=1200&enable=upscale"
                }
            };
        }
    }
}