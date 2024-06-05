package Models;
public class Book {
    //declare necessary fields
    private int ID;
    private String name;
    private String author;
    private String publisher;
    private String genre;
    private String ISBN;
    private long year;

    //book's constructor takes in necessary fields to create a book object
    public Book(String name, String author, String publisher, String genre, String iSBN, long year) {
        super();
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.genre = genre;
        this.ISBN = iSBN;
        this.year = year;
    }
    //second book constructor to be used when 'getBooks()' is called from the 'BookDAO'
    public Book(int ID,String name, String author, String publisher, String genre, String iSBN, long year) {
        super();
        this.ID = ID;
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.genre = genre;
        this.ISBN = iSBN;
        this.year = year;
    }
    //auto-generated getters/setters for each relevant field so that the values can be set/read
    public int getID() {
        return ID;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getAuthor() {
        return author;
    }
    public void setAuthor(String author) {
        this.author = author;
    }
    public String getPublisher() {
        return publisher;
    }
    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }
    public String getGenre() {
        return genre;
    }
    public void setGenre(String genre) {
        this.genre = genre;
    }
    public String getISBN() {
        return ISBN;
    }
    public void setISBN(String iSBN) {
        ISBN = iSBN;
    }
    public long getYear() {
        return year;
    }
    public void setYear(long year) {
        this.year = year;
    }
    public boolean equals(Book book){
        if(this.ID == book.ID) {
            return true;
        }
        return false;
    }
    @Override
    //toString to display a book in this way when it is printed
    public String toString() {
        return "ID: " + ID + " Name: " + name;
    }
}

