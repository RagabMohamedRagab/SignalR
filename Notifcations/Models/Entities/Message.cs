using System.ComponentModel.DataAnnotations.Schema;

namespace Notifcations.Models.Entities {
    public class Message {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime time { get; set; }
        [ForeignKey(nameof(user))]
        public string UserId { get; set; }
        public virtual Appuser user { get; set; }
    }
}




