using Microsoft.EntityFrameworkCore;

namespace Core
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoriamedicamento> Categoriamedicamento { get; set; }
        public virtual DbSet<Farmacia> Farmacia { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
        public virtual DbSet<Medicamentodisponivel> Medicamentodisponivel { get; set; }
        public virtual DbSet<Solicitacaomedicamento> Solicitacaomedicamento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //{
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            // optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Idrug@123456;database=BD_IDRUG");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoriamedicamento>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("categoriamedicamento");

                entity.HasIndex(e => e.IdCategoriaMedicamento)
                    .HasName("idCategoriaMedicamento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCategoriaMedicamento)
                    .HasColumnName("idCategoriaMedicamento")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasColumnName("nomeCategoria")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Farmacia>(entity =>
            {
                entity.HasKey(e => e.IdFarmacia)
                    .HasName("PRIMARY");

                entity.ToTable("farmacia");

                entity.HasIndex(e => e.IdFarmacia)
                    .HasName("idFarmacia_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdFarmacia)
                    .HasColumnName("idFarmacia")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('ATIVA','INATIVA')")
                    .HasDefaultValueSql("'INATIVA'");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("medicamento");

                entity.HasIndex(e => e.IdCategoriaMedicamento)
                    .HasName("fk_Medicamento_CategoriaMedicamento1_idx");

                entity.HasIndex(e => e.IdMedicamento)
                    .HasName("idMedicamento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");

                entity.Property(e => e.CodigoBarras)
                    .IsRequired()
                    .HasColumnName("codigoBarras")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fabricante)
                    .IsRequired()
                    .HasColumnName("fabricante")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoriaMedicamento)
                    .HasColumnName("idCategoriaMedicamento")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaMedicamentoNavigation)
                    .WithMany(p => p.Medicamento)
                    .HasForeignKey(d => d.IdCategoriaMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idCategoriaMedicamento");
            });

            modelBuilder.Entity<Medicamentodisponivel>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilizacaoMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("medicamentodisponivel");

                entity.HasIndex(e => e.IdDisponibilizacaoMedicamento)
                    .HasName("idDisponibilizacaoMedicamento_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdFarmacia)
                    .HasName("fk_MedicamentoDisponivel_Farmacia1_idx");

                entity.HasIndex(e => e.IdMedicamento)
                    .HasName("fk_TB_FARMACIA_has_TB_MEDICAMENTO_TB_MEDICAMENTO1_idx");

                entity.Property(e => e.IdDisponibilizacaoMedicamento)
                    .HasColumnName("idDisponibilizacaoMedicamento")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.DataFimDisponibilizacao).HasColumnName("dataFimDisponibilizacao");

                entity.Property(e => e.DataInicioDisponibilizacao).HasColumnName("dataInicioDisponibilizacao");

                entity.Property(e => e.DataVencimento).HasColumnName("dataVencimento");

                entity.Property(e => e.IdFarmacia)
                    .HasColumnName("idFarmacia")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");

                entity.Property(e => e.Imagem)
                    .HasColumnName("imagem")
                    .HasColumnType("blob");

                entity.Property(e => e.Lote)
                    .IsRequired()
                    .HasColumnName("lote")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnName("quantidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuantidadeDisponibilizacao).HasColumnName("quantidadeDisponibilizacao");

                entity.Property(e => e.QuantidadeDisponivel).HasColumnName("quantidadeDisponivel");

                entity.Property(e => e.QuantidadeEntregue).HasColumnName("quantidadeEntregue");

                entity.Property(e => e.QuantidadeReservada).HasColumnName("quantidadeReservada");

                entity.Property(e => e.StatusMedicamento)
                    .IsRequired()
                    .HasColumnName("statusMedicamento")
                    .HasColumnType("enum('RESERVADO','DISPONIVEL','INDISPONIVEL')")
                    .HasDefaultValueSql("'DISPONIVEL'");

                entity.Property(e => e.ValidadeAno)
                    .IsRequired()
                    .HasColumnName("validadeAno")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ValidadeMes).HasColumnName("validadeMes");

                entity.HasOne(d => d.IdFarmaciaNavigation)
                    .WithMany(p => p.Medicamentodisponivel)
                    .HasForeignKey(d => d.IdFarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MedicamentoDisponivel_Farmacia1");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.Medicamentodisponivel)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idMedicamento");
            });

            modelBuilder.Entity<Solicitacaomedicamento>(entity =>
            {
                entity.HasKey(e => e.IdSolicitacaoMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("solicitacaomedicamento");

                entity.HasIndex(e => e.IdDisponibilizacaoMedicamento)
                    .HasName("fk_tbDisponibilizaMedicamento_has_tbUsuario_tbDisponibiliza_idx");

                entity.HasIndex(e => e.IdSolicitacaoMedicamento)
                    .HasName("idSolicitacaoMedicamento_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_tbDisponibilizaMedicamento_has_tbUsuario_tbUsuario1_idx");

                entity.Property(e => e.IdSolicitacaoMedicamento).HasColumnName("idSolicitacaoMedicamento");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DataEntrega).HasColumnName("dataEntrega");

                entity.Property(e => e.DataSolicitacao).HasColumnName("dataSolicitacao");

                entity.Property(e => e.IdDisponibilizacaoMedicamento)
                    .HasColumnName("idDisponibilizacaoMedicamento")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PrazoEntrega).HasColumnName("prazoEntrega");

                entity.Property(e => e.QuantidadeEntregue).HasColumnName("quantidadeEntregue");

                entity.Property(e => e.QuantidadeSolicitada).HasColumnName("quantidadeSolicitada");

                entity.Property(e => e.StatusSolicitacaoMedicamento)
                    .IsRequired()
                    .HasColumnName("statusSolicitacaoMedicamento")
                    .HasColumnType("enum('CONCLUIDA','EM ANDAMENTO','CANCELADA')")
                    .HasDefaultValueSql("'EM ANDAMENTO'");

                entity.HasOne(d => d.IdDisponibilizacaoMedicamentoNavigation)
                    .WithMany(p => p.Solicitacaomedicamento)
                    .HasForeignKey(d => d.IdDisponibilizacaoMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idDisponibilizacaoMedicamento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitacaomedicamento)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdFarmacia)
                    .HasName("fk_TB_USUARIO_TB_FARMACIA1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("idUsuario_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IdFarmacia)
                    .HasColumnName("idFarmacia")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("tipoUsuario")
                    .HasColumnType("enum('ADMINISTRADOR','FARMACEUTICO','SOLICITANTE')")
                    .HasDefaultValueSql("'SOLICITANTE'");

                entity.HasOne(d => d.IdFarmaciaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdFarmacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idFarmacia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
