using Interview.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Interview.API.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly IDistributedCache _redisCache;

        public StudentRepo(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _redisCache.SetStringAsync(student.Id.ToString(), JsonConvert.SerializeObject(student));

            return await GetStudent(student.Id);
        }

        public async Task<Student> GetStudent(int id)
        {
            var jsonData = await _redisCache.GetStringAsync(id.ToString());
            return JsonConvert.DeserializeObject<Student>(jsonData);
        }
    }
}
