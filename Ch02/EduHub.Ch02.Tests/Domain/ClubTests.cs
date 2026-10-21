
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Tests.Domain;

public class ClubTests
{
    [Fact]
    public void Create_WithValidName_ReturnsClubWithNameAndNewId()
    {
        const string name = "Tech Club";

        var club = Club.Create(name, "Câu lạc bộ công nghệ");

        Assert.Equal(name, club.Name);
        Assert.NotEqual(Guid.Empty, club.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithBlankName_ThrowsArgumentException(string name)
    {
        var act = () => Club.Create(name, "Mô tả");

        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Create_WithNameLongerThan100_ThrowsArgumentException()
    {
        var longName = new string('a', Club.MaxNameLength + 1);

        var act = () => Club.Create(longName, "Mô tả");

        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(49, true)]
    [InlineData(50, false)]
    public void HasRoom_DependsOnCurrentMemberCount(
        int memberCount, bool expected)
    {
        var club = Club.Create("Tech Club", "Mô tả");

        var result = club.HasRoom(memberCount);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Create_WithNameExactly100Characters_Succeeds()
    {
        var name = new string('A', Club.MaxNameLength);

        var club = Club.Create(name, "Test description");

        Assert.Equal(100, club.Name.Length);
        Assert.Equal(name, club.Name);
    }
}
