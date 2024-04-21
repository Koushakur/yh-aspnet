//using Infrastructure.Entities;
//using Infrastructure.Repositories;
//using System.Diagnostics;
//using System.Linq.Expressions;

//namespace Infrastructure.Services;

//public class CourseService(CourseRepository courseRepository) {
//    private readonly CourseRepository _courseRepository = courseRepository;

//    public async Task<CourseEntity> CreateOrUpdateAsync(int id, string imageURL, string title, string author, string priceOriginal, int hours, int likes, float likePercentage, string? priceDiscounted, bool? bestSeller) {
//        try {
//            var tCourse = new CourseEntity {
//                ImageURL = imageURL,
//                Title = title,
//                Author = author,
//                PriceOriginal = priceOriginal,
//                PriceDiscounted = priceDiscounted,
//                BestSeller = bestSeller,
//                Hours = hours,
//                Likes = likes,
//                LikePercentage = likePercentage,
//            };

//            Expression<Func<CourseEntity, bool>> tExp = (x => x.Id == id);

//            if (await _courseRepository.ExistsAsync(tExp)) {
//                if (await _courseRepository.UpdateEntityAsync(tExp, tCourse))
//                    return tCourse;
//                else
//                    return null!;
//            } else
//                return await _courseRepository.Create(tCourse);

//        } catch (Exception e) { Debug.WriteLine(e); }
//        return null!;
//    }

//    public async Task<bool> UpdateAsync(int id, string imageURL, string title, string author, string priceOriginal, int hours, int likes, float likePercentage, string? priceDiscounted, bool? bestSeller) {
//        try {
//            var tCourse = new CourseEntity {
//                ImageURL = imageURL,
//                Title = title,
//                Author = author,
//                PriceOriginal = priceOriginal,
//                PriceDiscounted = priceDiscounted,
//                BestSeller = bestSeller,
//                Hours = hours,
//                Likes = likes,
//                LikePercentage = likePercentage,
//            };

//            Expression<Func<CourseEntity, bool>> tExp = (x => x.Id == id);

//            if (await _courseRepository.ExistsAsync(tExp)) {
//                return await _courseRepository.UpdateEntityAsync(tExp, tCourse);
//            }

//        } catch (Exception e) { Debug.WriteLine(e); }
//        return false;
//    }
//}