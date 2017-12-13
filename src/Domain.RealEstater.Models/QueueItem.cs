using System;
using Newtonsoft.Json;

namespace Domain.RealEstater.Models
{
    public class QueueItem<T>
    {
        public string IdStr { get; set; }
        public string MessageStr { get; set; }

        public T Message
        {
            get => JsonConvert.DeserializeObject<T>(MessageStr);
            set => MessageStr = JsonConvert.SerializeObject(value);
        }

        public Guid Id
        {
            get => Guid.Parse(IdStr);
            set => IdStr = value.ToString("N");
        }
    }
}