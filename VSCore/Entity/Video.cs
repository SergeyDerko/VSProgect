using System.ComponentModel.DataAnnotations;

namespace VSCore.Entity
{
    /// <summary>
    /// Видео сайта
    /// </summary>
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public virtual News News { get; set; }

        public virtual Business Business { get; set; }

        public virtual Useful Useful {get; set; }
    }
}
