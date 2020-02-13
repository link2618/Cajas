using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cajasqlserver.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto()
        {

        }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        //propiedades para exponer el modelo
        public virtual DbSet<t_tipo_caja> ttipocaja { get; set; }
        public virtual DbSet<t_caja> tcaja { get; set; }
        public virtual DbSet<t_carpeta> tcarpeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JI5A1PF;Initial Catalog=dbcajas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder) 
         {
             modelBuilder.Entity<t_tipo_caja>(entity => {
                 entity.ToTable("t_tipo_caja"); //nombre de la tabla
                 entity.HasKey(e => e.idtipocaja); //llave primaria
                 entity.Property(e => e.idtipocaja).HasColumnName("idtipocaja"); //nombre de la columna 

                 entity.Property(e => e.nombre)
                 .HasColumnName("nombre")
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false); //IsUnicode(false) indica que la columna de la bd se almacenara como un varchar y no como un nvarchar
             });

             modelBuilder.Entity<t_caja>(entity => {
                 entity.ToTable("t_caja");
                 entity.HasKey(e => e.idtcaja);
                 entity.Property(e => e.idtcaja).HasColumnName("idcaja");

                 entity.Property(e => e.tipo).HasColumnName("tipo");

                 entity.Property(e => e.usuario)
                 .HasColumnName("usuario")
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false);

                 entity.Property(e => e.anio)
                 .HasColumnName("anio")
                 .IsRequired();

                 //relacion de las tablas de uno (t_tipo_caja) a muchos (t_caja) 
                 entity.HasOne(t => t.rtipocaja) //la referencia de tipo de caja de la clase t_caja
                 .WithMany(c => c.lcaja) //el listado de cajas de t_tipo_caja
                 .HasForeignKey(t => t.tipo) //llave foranea de t_caja
                 .OnDelete(DeleteBehavior.ClientCascade) //tipo de eliminacion
                 .HasConstraintName("FK_tcaja_tipocaja");
             });

             modelBuilder.Entity<t_carpeta>(entity => {
                 entity.ToTable("t_carpeta");
                 entity.HasKey(e => e.idcarpeta);
                 entity.Property(e => e.idcarpeta).HasColumnName("idcarpeta");

                 entity.Property(e => e.nit).HasColumnName("nit");

                 entity.Property(e => e.caja).HasColumnName("caja");

                 //relacion de las tablas de uno (t_caja) a muchos (t_carpeta) 
                 entity.HasOne(c => c.rcaja) //la referencia de la caja de la clase t_carpeta
                 .WithMany(c => c.lcarpeta) //el listado de carpetas de t_caja
                 .HasForeignKey(t => t.caja) //llave foranea de t_carpeta
                 .OnDelete(DeleteBehavior.ClientCascade) //tipo de eliminacion
                 .HasConstraintName("FK_tcarpeta_tcaja");
             });
         }*/
    }
}
