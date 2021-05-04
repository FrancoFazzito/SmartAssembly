using Domain.Components;

namespace WebApi.Controllers.Components
{
    public partial class ComponentController
    {
        public class ComponentParam            
        { 
            public int? Id { get; set; }
            public Component Component { get; set; }
        }
    }
}