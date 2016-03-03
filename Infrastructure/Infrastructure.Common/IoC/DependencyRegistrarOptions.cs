using System;

namespace Infrastructure.Common.IoC
{
    public class DependencyRegistrarOptions
    {
        public string Name { get; set; }
        public Type From { get; set; }
        public Type To { get; set; }
        public bool Singleton { get; set; }
        public object SingletonInstance { get; set; }
        public object[] ConstuctorParameters { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, From: {1}, To:{2}, Singleton:{3}",
                Name ?? string.Empty, From == null ? string.Empty : From.ToString(), To == null ? string.Empty : To.ToString(), Singleton);
        }
    }
}
