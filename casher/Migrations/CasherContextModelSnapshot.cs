// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using casher.Properties.model;

namespace casher.Migrations
{
    [DbContext(typeof(CasherContext))]
    partial class CasherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("casher.Properties.model.Adminn", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("casher.Properties.model.Categoryy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("casher.Properties.model.Customerr", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("change")
                        .HasColumnType("real");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("casher.Properties.model.OrderItemm", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<float>("DiscountPrice")
                        .HasColumnType("real");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<float>("sellingPrice")
                        .HasColumnType("real");

                    b.Property<float>("totalPrice")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("OrderId");

                    b.HasIndex("productId");

                    b.ToTable("orderItems");
                });

            modelBuilder.Entity("casher.Properties.model.Orderr", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<float>("totalPayment")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("casher.Properties.model.Productt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoretId")
                        .HasColumnType("int");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("originalPrice")
                        .HasColumnType("real");

                    b.Property<string>("productCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("productQuantity")
                        .HasColumnType("int");

                    b.Property<float?>("sellingPrice")
                        .HasColumnType("real");

                    b.Property<int?>("storeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("storeid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("casher.Properties.model.Storee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("producttId")
                        .HasColumnType("int");

                    b.Property<int>("producttQuantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("casher.Properties.model.OrderItemm", b =>
                {
                    b.HasOne("casher.Properties.model.Orderr", "order")
                        .WithMany("items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casher.Properties.model.Productt", "product")
                        .WithMany("items")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("casher.Properties.model.Orderr", b =>
                {
                    b.HasOne("casher.Properties.model.Customerr", "customer")
                        .WithMany("orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("casher.Properties.model.Productt", b =>
                {
                    b.HasOne("casher.Properties.model.Categoryy", "category")
                        .WithMany("products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casher.Properties.model.Storee", "store")
                        .WithMany("products")
                        .HasForeignKey("storeid");

                    b.Navigation("category");

                    b.Navigation("store");
                });

            modelBuilder.Entity("casher.Properties.model.Categoryy", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("casher.Properties.model.Customerr", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("casher.Properties.model.Orderr", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("casher.Properties.model.Productt", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("casher.Properties.model.Storee", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
