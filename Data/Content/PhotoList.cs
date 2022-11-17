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
                    AnimalId = 1,
                    Source = "https://images.unsplash.com/flagged/photo-1566127992631-137a642a90f4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&w=1000&q=80"
                },
                new Photo
                {
                    AnimalId = 1,
                    Source = "https://img.i-scmp.com/cdn-cgi/image/fit=contain,width=1098,format=auto/sites/default/files/styles/1200x800/public/d8/images/canvas/2022/02/15/6e8c06d1-a685-4242-ae53-f668717186d3_dceb3cfd.jpg?itok=1gvwtf1t&v=1644930191"
                },
                new Photo
                {
                    AnimalId = 1,
                    Source = "https://prod.static9.net.au/fs/a79a7806-d006-4ec6-bdbe-46b98e4888b7"
                },
                new Photo
                {
                    AnimalId = 2,
                    Source = "https://www.treehugger.com/thmb/kaA2K_9wVzTbPIyCRm3-oZuy6k0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/horse.primary-e9a47e1c486c4fb7bf729e05b59cf0df.jpg"
                },
                new Photo
                {
                    AnimalId = 2,
                    Source = "http://www.chovzvirat.cz/images/zvirata/quarter-horse_sfm38qb.jpg"
                },
                new Photo
                {
                    AnimalId = 2,
                    Source = "https://media.gq.com/photos/56e71c0b14cbe0637b261d7f/1:1/w_1696,h_1696,c_limit/horseinsuit2.jpg"
                },
                new Photo
                {
                    AnimalId = 3,
                    Source = "https://i.guim.co.uk/img/media/fe1e34da640c5c56ed16f76ce6f994fa9343d09d/0_174_3408_2046/master/3408.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=0d3f33fb6aa6e0154b7713a00454c83d"
                },
                new Photo
                {
                    AnimalId = 3,
                    Source = "https://ichef.bbci.co.uk/news/976/cpsprodpb/17638/production/_124800859_gettyimages-817514614.jpg"
                },
                new Photo
                {
                    AnimalId = 3,
                    Source = "https://post.healthline.com/wp-content/uploads/2020/08/3180-Pug_green_grass-732x549-thumbnail-732x549.jpg"
                },
                new Photo
                {
                    AnimalId = 3,
                    Source = "https://www.scotsman.com/webimg/b25lY21zOjViZjVjYjc0LTgwZDctNGE4Zi1iNWZiLTE1MDA3YzAyNzJjYTowNWY3YWEwMy04MTAxLTRmMWEtOTU3Ny1kZTk0ODJjNGJkNjc=.jpg?width=1200&enable=upscale"
                }
            };
        }
    }
}