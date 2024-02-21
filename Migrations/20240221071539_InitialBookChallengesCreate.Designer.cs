﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookChallengeAPI.Migrations
{
    [DbContext(typeof(ChallengeDbContext))]
    [Migration("20240221071539_InitialBookChallengesCreate")]
    partial class InitialBookChallengesCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pages")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "Set in the summer of 1922 on Long Island and in New York City, this classic novel captures the essence of the Jazz Age with its lavish parties, love affairs, and societal commentary.",
                            Genre = "Classic",
                            Language = "English",
                            Pages = "180",
                            Title = "The Great Gatsby",
                            Url = "https://www.goodreads.com/book/show/4671.The_Great_Gatsby",
                            Year = 1925
                        },
                        new
                        {
                            Id = 2,
                            Author = "Sue Monk Kidd",
                            Description = "Set in South Carolina during the summer of 1964, this novel follows a young girl named Lily Owens as she embarks on a journey to uncover the truth about her mother's past and finds solace and healing in the company of beekeeping sisters.",
                            Genre = "Fiction",
                            Language = "English",
                            Pages = "302",
                            Title = "The Secret Life of Bees",
                            Url = "https://www.goodreads.com/book/show/37435.The_Secret_Life_of_Bees",
                            Year = 2001
                        },
                        new
                        {
                            Id = 3,
                            Author = "Emma Straub",
                            Description = "This novel takes place during a two-week family vacation in Mallorca, Spain, where secrets and tensions bubble to the surface as the Post family navigates love, betrayal, and redemption.",
                            Genre = "Fiction",
                            Language = "English",
                            Pages = "292",
                            Title = "The Vacationers",
                            Url = "https://www.goodreads.com/book/show/18641982-the-vacationers",
                            Year = 2014
                        },
                        new
                        {
                            Id = 4,
                            Author = "Erin Morgenstern",
                            Description = "This enchanting novel follows the mysterious Le Cirque des Rêves, a circus that arrives without warning and is only open at night. The story unfolds over many years, capturing the magic and romance of autumn.",
                            Genre = "Fiction",
                            Language = "English",
                            Pages = "506",
                            Title = "The Night Circus",
                            Url = "https://www.goodreads.com/book/show/9361589-the-night-circus",
                            Year = 2011
                        },
                        new
                        {
                            Id = 5,
                            Author = "Donna Tartt",
                            Description = "This atmospheric novel is set in a New England college town during the fall semester. It follows a group of eccentric classics students who become entangled in a dark and sinister secret.",
                            Genre = "Classic",
                            Language = "English",
                            Pages = "559",
                            Title = "The Secret History",
                            Year = 1992
                        });
                });

            modelBuilder.Entity("BookChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("ChallengeBooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            ChallengeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            ChallengeId = 1
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            ChallengeId = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            ChallengeId = 2
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            ChallengeId = 2
                        });
                });

            modelBuilder.Entity("BookDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ChallengeDtoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pages")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeDtoId");

                    b.ToTable("BookDto");
                });

            modelBuilder.Entity("Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfBooks")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfUsers")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Challenges");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Read books set in summer",
                            Name = "summer reading",
                            NoOfBooks = 5,
                            NoOfUsers = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Read books set in autumn",
                            Name = "autumn reading",
                            NoOfBooks = 5,
                            NoOfUsers = 0
                        });
                });

            modelBuilder.Entity("ChallengeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfBooks")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfUsers")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChallengeDto");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfChallenges")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Book", b =>
                {
                    b.HasOne("Challenge", null)
                        .WithMany("Books")
                        .HasForeignKey("ChallengeId");
                });

            modelBuilder.Entity("BookChallenge", b =>
                {
                    b.HasOne("Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Challenge");
                });

            modelBuilder.Entity("BookDto", b =>
                {
                    b.HasOne("ChallengeDto", null)
                        .WithMany("Books")
                        .HasForeignKey("ChallengeDtoId");
                });

            modelBuilder.Entity("ChallengeDto", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("Challenges")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Challenge", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ChallengeDto", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
