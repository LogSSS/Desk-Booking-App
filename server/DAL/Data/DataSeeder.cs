using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace DAL.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking
                    {
                        Id = 1,
                        Name = "Alice",
                        Email = "alice@example.com",
                        OwnerId = 1,
                        WorkspaceId = 1,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 25, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 26, 18, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        RoomSize = 0,
                    },
                    new Booking
                    {
                        Id = 2,
                        Name = "Bob",
                        Email = "bob@example.com",
                        OwnerId = 2,
                        WorkspaceId = 2,
                        StartDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 27, 10, 0, 0),
                            DateTimeKind.Utc
                        ),
                        EndDate = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 28, 18, 0, 0),
                            DateTimeKind.Utc
                        ),
                        CreatedAt = DateTime.SpecifyKind(
                            new DateTime(2025, 6, 1, 12, 0, 0),
                            DateTimeKind.Utc
                        ),
                        Status = Status.Active,
                        RoomSize = 1,
                    }
                );

            modelBuilder
                .Entity<Workspace>()
                .HasData(
                    new Workspace
                    {
                        Id = 1,
                        Name = "Open Space",
                        Type = WorkspaceType.OpenSpace,
                        Description = """
                            A vibrant shared area perfect for freelancers or small teams 
                            who enjoy a collaborative atmosphere. Choose any
                            available desk and get to work with flexibility and ease.
                        """,
                    },
                    new Workspace
                    {
                        Id = 2,
                        Name = "Private Rooms",
                        Type = WorkspaceType.PrivateRooms,
                        Description = """
                            Ideal for focused work, video calls, or small 
                            team huddles.These fully enclosed rooms offer privacy and
                            come in a variety of sizes to fit your needs.
                        """,
                    },
                    new Workspace
                    {
                        Id = 3,
                        Name = "Meeting Rooms",
                        Type = WorkspaceType.MeetingRooms,
                        Description = """
                           Designed for productive meetings, workshops, 
                           or client presentations. Equipped with screens, whiteboards,
                           and comfortable seating to keep your sessions running smoothly.
                        """,
                    }
                );

            modelBuilder
                .Entity<Amenity>()
                .HasData(
                    new Amenity
                    {
                        Id = 1,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761603/air-conditioning_hvyv3h.svg",
                        WorkspaceId = 1,
                    },
                    new Amenity
                    {
                        Id = 2,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761679/device-gamepad-2_qoildh.svg",
                        WorkspaceId = 1,
                    },
                    new Amenity
                    {
                        Id = 3,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761516/wifi_jjuewr.svg",
                        WorkspaceId = 1,
                    },
                    new Amenity
                    {
                        Id = 4,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761514/coffee_d8zhut.svg",
                        WorkspaceId = 1,
                    },
                    new Amenity
                    {
                        Id = 5,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761516/wifi_jjuewr.svg",
                        WorkspaceId = 2,
                    },
                    new Amenity
                    {
                        Id = 6,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761603/airconditioning_hvyv3h.svg",
                        WorkspaceId = 2,
                    },
                    new Amenity
                    {
                        Id = 7,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761514/headphones_bosvcs.svg",
                        WorkspaceId = 2,
                    },
                    new Amenity
                    {
                        Id = 8,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761516/wifi_jjuewr.svg",
                        WorkspaceId = 3,
                    },
                    new Amenity
                    {
                        Id = 9,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761603/airconditioning_hvyv3h.svg",
                        WorkspaceId = 3,
                    },
                    new Amenity
                    {
                        Id = 10,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761514/headphones_bosvcs.svg",
                        WorkspaceId = 3,
                    },
                    new Amenity
                    {
                        Id = 11,
                        IconContent =
                            "https://res.cloudinary.com/darmngqvc/image/upload/v1749761515/microphone_vzi239.svg",
                        WorkspaceId = 3,
                    }
                );

            modelBuilder
                .Entity<Capacity>()
                .HasData(
                    new Capacity { Id = 1, WorkspaceId = 1 },
                    new Capacity { Id = 2, WorkspaceId = 2 },
                    new Capacity { Id = 3, WorkspaceId = 3 }
                );

            modelBuilder
                .Entity<RoomAvailability>()
                .HasData(
                    new RoomAvailability
                    {
                        Id = 1,
                        CapacityId = 1,
                        MaxPeople = 0,
                        AvailableRooms = 24,
                    },
                    new RoomAvailability
                    {
                        Id = 2,
                        CapacityId = 2,
                        MaxPeople = 1,
                        AvailableRooms = 7,
                    },
                    new RoomAvailability
                    {
                        Id = 3,
                        CapacityId = 2,
                        MaxPeople = 2,
                        AvailableRooms = 4,
                    },
                    new RoomAvailability
                    {
                        Id = 4,
                        CapacityId = 2,
                        MaxPeople = 5,
                        AvailableRooms = 3,
                    },
                    new RoomAvailability
                    {
                        Id = 5,
                        CapacityId = 2,
                        MaxPeople = 10,
                        AvailableRooms = 1,
                    },
                    new RoomAvailability
                    {
                        Id = 6,
                        CapacityId = 3,
                        MaxPeople = 10,
                        AvailableRooms = 4,
                    },
                    new RoomAvailability
                    {
                        Id = 7,
                        CapacityId = 3,
                        MaxPeople = 20,
                        AvailableRooms = 1,
                    }
                );

            modelBuilder
                .Entity<MyImage>()
                .HasData(
                    new MyImage
                    {
                        Id = 1,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/e90b/b3f8/c112a868ce37c2a7181d36e2a8b39e51?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=r4WFswFPMfpRWy0Uz4fPWThiHZdEPY57WBROkR0oJ-z7obtw87DYZhbIMuXmXr2-9mq28ZyZ9AP~nDx3ZMnSNXV7J3-0Sy6QTAjkkg78Ea2xsoK~QVKTJz2QA0XNtNybangADglO18gIzbvtwYL0C0N3qG~41P1A1RUM5R0gp53N88-dst16WGrS28pvdrQa0Lnujkri7xHmH8iatgbDg-EZ4E36xJ8-n6up~i~7YY8h44ze3lBIwdX7mR21hJLWQjP3WyD~~FEq9BuCnfcbMKYzx2B222Rj7v1P3qZ2imd-E96netj5IVO7plmN~8dBO1E9Yr5ABatnKRPe5kyZOg__",
                        WorkspaceId = 1,
                    },
                    new MyImage
                    {
                        Id = 2,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/1019/31b7/ae6f38119bf6b9fa9832610f6c6497ef?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=j8OquCYNSPnEoIOiqAL-4HhRgIYI0ikbCWS-LnLPCBJeMU~ZcWNCzvaji6Pts6hqcO6HU2t46CUr4vd-mie~byAZn45iDTuD7AZd8KJMO8ZiN4uMUntkxGQk0uU-~kB7pjM1Fx59YHMPcXP5Zh14F7q74QP0Bv~ivpyl6H1PnYeGDAnosKwgP6bFt8ld~ZhOWMSh6i~PVkCW-Eptkd4LzdbenfpOPGwu39nqPprnrIsdBGJ4NghECy~MXDLo-wlEu-QsAWNddzAZuARPYw05if1~puhhXCoiOw3DbBF29Xiv3BpOVuLZHeF2BCWmIIgVDL5SRGe5GvNE-fTkQlISzA__",
                        WorkspaceId = 1,
                    },
                    new MyImage
                    {
                        Id = 3,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/3b13/dc57/f5288df1675a9f4dc8fcaef0553a0f90?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=A02tkbwZqR2A78jOjD~sKUpyDEVBlXlVaulDWDZFdU1HeWmNroVVDAj1m4Qz58sVVrRGQ-36i0O3u8E1lVf-ocZxSezigEGjEORRp~32hCVky22UYLueTeIZ2D8c4X5moARagqKpUzdcN46YI4l2KT26GOnrv7keFrZp5yYg3iep7LmZL-Ud6EzGce2EkBJ~WNIIohiIFYcHOTTrd8yoPEvvIAJFopQ5-d~miuno~O5X~YoWKkzvHXqEKKPuevP-KX5COsHSyhjvacUoCJImFyNEiWlr~d-fDvHODPYKCXjADOJiSuw126hu~65i-F-j6GtA4pYPZGAUi~Rv3o3kmw__",
                        WorkspaceId = 1,
                    },
                    new MyImage
                    {
                        Id = 4,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/d565/3107/a69b20b64f00fb13a812060c8e0c1071?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=kOhxvFGGNSsHP7MrlzKZXh1NBWnNFty5izWErf6zcMHDvULI8C7PdAG5lMIsRSbLXTBbUfNR~B~XSe~izmeYpPkjMIf5N15fGDhGfZK8d8~Y0n7E5ebU56uaPzwqAKG-YjgEHDaoYWna0GBjJ~pPBrjscpKnXzJXT2dNY-SWbUTfIPV48cJbVzDZCEJhnvvi4r~iC~XnhdjJHC0MwPXWlp3IG2solTFTKMiL5FH5LLgyRvIzC1wxm9ZupUnVxilRHx3G~fyUlgOmJoaA0BOLibVTQ48WFagpfiDQK6~0Ezt1DhjYOVdBuKmeJo0fRlxab2f-qZisS5MEOl3N6T66TQ__",
                        WorkspaceId = 1,
                    },
                    new MyImage
                    {
                        Id = 5,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/6431/cca7/61fbd2d3bfb4d7f08a2f862c2fdeb6b1?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=Nv0sNW6BQXMCR0slcJYfjrN-BlXOu5ZuRR3X7jcjsBIHmtFnoAo~tVekAGVmCEBmcr0LpshOXd0v~rKTVKNiSKW4NtkAiqNw2wocBKqXudbgv2wgv2FVwxTn3-rnBXPJXWTQsZbvADEp2Js8nNp0CBqtBYnG~vu-7aYZH42NysWLfjR25Ymsly9TKSHewt6BbY-zGgQxotHLXPi217epx88IM46~nCMlvq4FGrFuNn4lt5o~P4nNvDVPS1Idfgx4k9jK1I4TCmLPhwgkc5xhj7kBEFTES5Jd1Z-fBR0CWS42sUGa0vu5LasdOz46BqH58C4sWQtyoJax-9kWj8aptw__",
                        WorkspaceId = 2,
                    },
                    new MyImage
                    {
                        Id = 6,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/4cb6/e6b2/ab60838a32a15fac8aca47acb834d1e7?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=l8PXCiIcJ0vn5lSygS5azP78zGxt4e2Zt6HaUhWy4EOewcvU61pX2ef1XBT7kPpuqZ806Xql9ZrdG9py3iLuzmD14SZT9HO8EnvnOBAGcQzuVSEK3SZ~noBb4q7p3e7NIL7Ec9PkLbdADtdcAiyI01z1iR7yIt4x-5a1osrinVl1TIEElp~6GWVu3w43nvFCcWF~WCH1m4AI3g5XvK7zLBawu7RqgvjEP3CJFAjJjcoZEYa4Frhv0ukivLCmGqQyNQrx7msAXuKGG0fMERgtXmh-4GWqI0SiUAR0hJ2BrWVtk0gsYYDPO1XYsuLFJyhizREWYJqUkAn35dOGecNzCg__",
                        WorkspaceId = 2,
                    },
                    new MyImage
                    {
                        Id = 7,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/6431/cca7/61fbd2d3bfb4d7f08a2f862c2fdeb6b1?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=Nv0sNW6BQXMCR0slcJYfjrN-BlXOu5ZuRR3X7jcjsBIHmtFnoAo~tVekAGVmCEBmcr0LpshOXd0v~rKTVKNiSKW4NtkAiqNw2wocBKqXudbgv2wgv2FVwxTn3-rnBXPJXWTQsZbvADEp2Js8nNp0CBqtBYnG~vu-7aYZH42NysWLfjR25Ymsly9TKSHewt6BbY-zGgQxotHLXPi217epx88IM46~nCMlvq4FGrFuNn4lt5o~P4nNvDVPS1Idfgx4k9jK1I4TCmLPhwgkc5xhj7kBEFTES5Jd1Z-fBR0CWS42sUGa0vu5LasdOz46BqH58C4sWQtyoJax-9kWj8aptw__",
                        WorkspaceId = 2,
                    },
                    new MyImage
                    {
                        Id = 8,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/d565/3107/a69b20b64f00fb13a812060c8e0c1071?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=kOhxvFGGNSsHP7MrlzKZXh1NBWnNFty5izWErf6zcMHDvULI8C7PdAG5lMIsRSbLXTBbUfNR~B~XSe~izmeYpPkjMIf5N15fGDhGfZK8d8~Y0n7E5ebU56uaPzwqAKG-YjgEHDaoYWna0GBjJ~pPBrjscpKnXzJXT2dNY-SWbUTfIPV48cJbVzDZCEJhnvvi4r~iC~XnhdjJHC0MwPXWlp3IG2solTFTKMiL5FH5LLgyRvIzC1wxm9ZupUnVxilRHx3G~fyUlgOmJoaA0BOLibVTQ48WFagpfiDQK6~0Ezt1DhjYOVdBuKmeJo0fRlxab2f-qZisS5MEOl3N6T66TQ__",
                        WorkspaceId = 2,
                    },
                    new MyImage
                    {
                        Id = 9,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/07e1/0141/c7a2c2d51b36e43d4ca73d7c0753ed5b?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=W0FD~TcO8~t9LTwE2vGqiwnYpYBs1aqT22yqO4CTyW6r67UF23icDps45rwMfPsdB-W4WyCYOM3Cu-kJwxR~fK6hsGAenyhzoEQ6MZOt75M8FRcylCOO-iIVqij9SS1nvgLFhJHFvhe4hf5Nf7V~jlG1LEYRfAOUuIsp~byI-47PshinM5g5zj1yQ7Ya8E4YjGxLX0B5jGqbF-BXnfR8IGW1yfy1etBbnU82IkyP7AxNqyB-gxV3-KxiLRLZPDHds9Ba8YMeFpeU-wNbDX~xdHN~3Xzhq-BgPMR-QUZGecCynQaf8L4ykGA7FkwVFVxhDIuffjud6GsfWjvdRb3l9A__",
                        WorkspaceId = 3,
                    },
                    new MyImage
                    {
                        Id = 10,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/0fa6/936c/82bab3a7caab82b4c277f6a732667f5a?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=erM33Kforedgw66sL1OX4csOwvHEyx4WWZSP-GZP4KIgLxbh7JobfY5Bjbew~HXb5hT~fi8fdKDxQE4o3ohr-fM3zqGnv2b4SM4UB6hmAjqmyIfTv-hgkUY7g7F5i35UXwNiKK8Dneg5G9M3~Q8ngZkXfoq7mRvuWNTGMhGGegFiOGOmyq2iDkxTmhyN0CPhQi5Uhhojiyf~bXawbBJh2xE5Rw6jLOhWy6bnGcSTXV4~T2R7MRYPjytWeg9mIunwn0grUro6pW3nG6KuRxM2jRjz0lT7u9QcJi3pJAs4iiQNNqvWrVZ9QORZRE0IF3NKuPiyS99LSRiZkrQsWcEmqg__",
                        WorkspaceId = 3,
                    },
                    new MyImage
                    {
                        Id = 11,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/0ab5/a14f/0fdcf9012f51cd4b501c5ca12e98c72e?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=PxT2dSaYT~ZZMmsdPBggySG1bj8bkI6Zmi3HKir2P5Cpw0BbcuWwDmrPaJfq9f4svZTj79r2ZRISlcZ~Uowo0Lsn6K3qG-ArzmuCIhwtfqAhGF~8wjC6Y-4PEKFTfqqABLmUHmZMKLxi7zyfJvJqjRBYgY9tTkyi-7vZRPC8212IMRnmtKP6Z6k9McWJ0v-e6e3kNUa6b8wpRibHz7mVPa91~86XlgrfXyfNA5~AehdqweH5Rw1V50GUd2MtEvm3Gpq-OB0Ft4KSxQSteShz1~I-DAlNIzkq1MrsemOC8hTsgX4Iq29gcvZ1B4KOgAaI822FEy6Canopwvgi-AV0ZQ__",
                        WorkspaceId = 3,
                    },
                    new MyImage
                    {
                        Id = 12,
                        Link =
                            "https://s3-alpha-sig.figma.com/img/afc3/b33e/8090e3f9bcad561d128a8719faad4c3d?Expires=1750636800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=mSIJmsITJyvxVf8Gi0x~5GDbvs6j2ZAtJrM2TRG07PHeD9Ozd7qRz0CQNHYJEa7aDt56CUWfFY7BbowzyiXmLWYibsD80D~IGPmI3y5-t5t2n4fr7bMGR3y3YCQijwQUiNDdE7hRzGqbNWwrlX-g1QAxsQ82qN9IFxh6iunVzDKlaITeNyxCZx5YmT0s8GmBixpxNC8YcIL2MNp0H2jVneiqGrMITNwfjgR-XQ-f4HzugDddczBHrhcQJAaadLQacItluHV1752dlVeQuqnY-73QuYrVVwTrHjDoqI62DRFywif12IhkVblp4z-PwLOiy9u7LOKS6tYhHgR~8wiFmA__",
                        WorkspaceId = 3,
                    }
                );
        }
    }
}
