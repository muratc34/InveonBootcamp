using Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(true);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Author)
            .IsRequired();

        builder.Property(x => x.AvailableCopies)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.Genre)
            .IsRequired();

        builder.Property(x => x.ISBN)
            .IsRequired();

        builder.Property(x => x.Language)
            .IsRequired();

        builder.Property(x => x.PageCount)
            .IsRequired();

        builder.Property(x => x.PublicationYear)
            .IsRequired();

        builder.Property(x => x.Publisher)
            .IsRequired();

        builder.Property(x => x.Summary)
            .IsRequired();

        builder.Property(x => x.Title)
        .IsRequired();

        builder.HasData(
            new Book("Don Quixote", "Miguel de Cervantes", 1605, "9780060934347", "Roman", "Harper & Row", 992, "İspanyolca", "Don Quixote is the story of a man who, after reading too many chivalric romances, decides to become a knight-errant and have adventures with his squire, Sancho Panza.", 5) { Id = 1 },
            new Book("Moby-Dick", "Herman Melville", 1851, "9781503280786", "Roman", "Richard Bentley", 635, "İngilizce", "Moby-Dick tells the adventures of the wandering sailor Ishmael, and his voyage on the whaleship Pequod, commanded by Captain Ahab, who is determined to hunt down the giant white whale Moby Dick.", 4) { Id = 2 },
            new Book("Pride and Prejudice", "Jane Austen", 1813, "9781503290563", "Roman", "T. Egerton, Whitehall", 279, "İngilizce", "The novel follows the life of Elizabeth Bennet as she deals with issues of manners, marriage, and family in early 19th-century England.", 10) { Id = 3 },
            new Book("War and Peace", "Leo Tolstoy", 1869, "9780140447934", "Tarihi Roman", "The Russian Messenger", 1225, "Rusça", "War and Peace chronicles the history of the Napoleonic wars in Russia and the intertwined lives of several aristocratic families.", 3) { Id = 4 },
            new Book("1984", "George Orwell", 1949, "9780451524935", "Distopya", "Secker and Warburg", 328, "İngilizce", "1984 is a dystopian novel set in a totalitarian society controlled by a figure known as Big Brother. The protagonist, Winston Smith, tries to rebel against the oppressive regime.", 6) { Id = 5 },
            new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "9780743273565", "Roman", "Charles Scribner's Sons", 180, "İngilizce", "The Great Gatsby tells the story of Jay Gatsby's quest to win back his lost love, Daisy Buchanan, amidst the excess and decadence of the Roaring Twenties.", 7) { Id = 6 },
            new Book("Crime and Punishment", "Fyodor Dostoevsky", 1866, "9780486454115", "Psikolojik Roman", "The Russian Messenger", 430, "Rusça", "Crime and Punishment tells the story of Rodion Raskolnikov, a young man who plans and carries out the murder of an old pawnbroker and then struggles with guilt and moral dilemmas.", 8) { Id = 7 },
            new Book("The Odyssey", "Homer", -800, "9780140268867", "Destan", "Penguin Classics", 541, "Eski Yunanca", "The Odyssey is an epic poem that tells the story of Odysseus's journey home after the fall of Troy, including encounters with mythical creatures and divine forces.", 2) { Id = 8 },
            new Book("To Kill a Mockingbird", "Harper Lee", 1960, "9780061120084", "Roman", "J.B. Lippincott & Co.", 281, "İngilizce", "To Kill a Mockingbird tells the story of a young girl named Scout Finch growing up in the racially segregated South, and her father, Atticus Finch, defending a black man accused of raping a white woman.", 9) { Id = 9 },
            new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "9780316769488", "Roman", "Little, Brown and Company", 277, "İngilizce", "The Catcher in the Rye follows Holden Caulfield, a disaffected teenager who is struggling with alienation and depression after being expelled from prep school.", 4) { Id = 10 },
            new Book("Küçük Prens", "Antoine De Saint Exupery", 2021, "9786257751353", "Roman", "Kapra Yayıncılık", 96, "Türkçe", "Antoine De Saint-Exupéry’nin Küçük Prens’i, çağdaş dünya edebiyatının en çok okunan ve belki de en çok sevilen eseri. Sadece çocukların değil, çocukluğunu içinde korumayı başarmış yetişkinlerin de büyük keyif alarak okuduğu bu eser, yazıldığı günden bu yana hemen hemen bütün dünya dillerine çevrilerek adeta insanlığın ortak miraslarından birine dönüşmüş durumda.“Ne esrarengiz bir olay. Evrende bir yerlerde, daha önce hiç görmediğimiz bir koyunun gülü yiyip yemediği, Küçük Prens’i çok seven bizler için ne kadar da önemli. Gökyüzüne bakın ve kendi kendinize şu soruyu sorun: ‘Koyun çiçeği yedi mi yemedi mi?’ Her şey nasıl da değişiyor göreceksiniz. Hiçbir yetişkin, bunun ne denli önemli olduğunu anlayamayacaktır!”", 1500) { Id = 11 }
        );
    }
}
