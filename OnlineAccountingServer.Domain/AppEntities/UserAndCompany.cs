using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Domain.AppEntities
{
    //Çoktan çoka ilişkiyi temsil etmek için genellikle birleşim tabloları kullanılır.
    //Bu durumda, UserAndCompany sınıfı, kullanıcı ve şirket arasındaki ilişkiyi temsil eden
    //birleşim tablosunu ifade eder. Bir kullanıcının birden çok şirkete bağlı olabilmesi ve
    //bir şirketin birden çok kullanıcıya bağlı olabilmesi için
    //AppUserId ve CompanyId özelliklerini kullanabilirsiniz
    public class UserAndCompany:Entity
    {
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
