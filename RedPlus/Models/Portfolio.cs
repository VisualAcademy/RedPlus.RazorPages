using System.Text.Json;

namespace RedPlus.Models
{
    /// <summary>
    /// 모델 클래스: Model, ViewModel, Dto, Object, Entity, ...
    /// </summary>
    public class Portfolio
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Portfolio>(this);
        }
    }
}
