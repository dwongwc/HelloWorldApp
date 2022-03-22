using AutoMapper;
using ConsoleApp1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AutoMapper Case 1: From A to B (all property are same) 
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<A, B>());
            //var mapper = config.CreateMapper();
            //var a = new A
            //{
            //    Id = 1,
            //    Name = "Name A"
            //};
            //var b = mapper.Map<B>(a);

            //AutoMapper Case 2: From A to B (a property is different) 
            //var config = new MapperConfiguration(
            //    cfg => cfg.CreateMap<A, C>().ForMember(x => x.RowId, y => y.MapFrom(o => o.Id))
            //);
            //var mapper = config.CreateMapper();
            //var a = new A
            //{
            //    Id = 1,
            //    Name = "Name A"
            //};
            //var c = mapper.Map<C>(a);

            //Combine AutoMapper Case 1 and 2
            //var config = new MapperConfiguration(
            //    cfg => {
            //        cfg.CreateMap<A, B>();
            //        cfg.CreateMap<A, C>().ForMember(x => x.RowId, y => y.MapFrom(o => o.Id));
            //        }
            //);
            //var mapper = config.CreateMapper();
            //var a = new A
            //{
            //    Id = 1,
            //    Name = "Name A"
            //};
            //var b = mapper.Map<B>(a);
            //var c = mapper.Map<C>(a);

            ////2.4	JSON
            string json = @"{
                              'loginName': 'tester03',
                              'email': 'mmak@nexify.com.hk',
                              'phone': '123456',
                              'fullName': 'tester03',
                              'createPrivateRepository': false,
                              'groupIds': [
                                0
                              ],
                              'isActivated': true,
                              'language': 'en',
                              'pwd': '123456',
                              'customize': {
                                'roleList': [
                                  'CFO',
                                  'MACC'
                                ]
                              }
                            }";

            // json string to JObject
            JObject o = JObject.Parse(json);
            // object to JObject
            JObject obj = JObject.FromObject(new A
            {
                Id = 101, Name = "Tom"
            });
            var objFromJObject = obj.ToObject<A>();

            //JObject to json string 
            string jsonWithHumanRead = o.ToString();
            string jsonForLogging = o.ToString(Formatting.None);
            Console.WriteLine(o.ToString());
            Console.WriteLine(o.ToString(Formatting.None));

            //Object to Json string
            var objectAForJson = new A { Id = 100, Name = "Hello" };
            string json2 = JsonConvert.SerializeObject(objectAForJson);
            Console.WriteLine(json2);

            //Json string to Object
            string jsonStr = @"{'id':999,'Name':'World'}";
            var objectAFromJsonStr = JsonConvert.DeserializeObject<A>(jsonStr);

            //serializerSettings
            var c01 = new C { RowId = 301, Name = "Jack" };
            var serializerSettings = new JsonSerializerSettings
            {
                // 设置为驼峰命名
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var c01Str = JsonConvert.SerializeObject(c01, serializerSettings);
            var c01StrData = JsonConvert.DeserializeObject<C>(c01Str);
            Console.WriteLine(c01Str);

            var c02 = new C { RowId = 302, Name = "Tommy" };
            var serializerSettings2 = new JsonSerializerSettings
            {
                // 设置为驼峰命名
                ContractResolver = new DefaultContractResolver()
            };
            var c02Str = JsonConvert.SerializeObject(c02, serializerSettings2);
            var c02StrData = JsonConvert.DeserializeObject<C>(c02Str);
            Console.WriteLine(c02Str);
            //// Json Part End
        }
    }
}
