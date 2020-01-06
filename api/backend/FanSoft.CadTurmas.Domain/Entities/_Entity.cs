using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public abstract class Entity 
    {
        public DateTime CriadoEm { get; protected set; } = DateTime.UtcNow;
        public DateTime AlteradoEm { get; protected set; } = DateTime.UtcNow;
        
     }
}