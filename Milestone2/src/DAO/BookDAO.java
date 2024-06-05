package DAO;
//imports
import Models.Book;
import java.sql.*;
import java.util.ArrayList;

public class BookDAO {
    //new connection
    Connection connection;
    //default constructor to initialize the connection and specify the database
    public BookDAO() throws SQLException {
        String url = "jdbc:sqlite:dbLib.db";
        connection = DriverManager.getConnection(url);
    }
    //method which takes in a book object and inserts it using the relevant fields into the database's 'books' table
    public void insertBook(Book b) throws SQLException {
        //statement for inserting into the books table
        PreparedStatement ps = connection.prepareStatement("INSERT INTO BOOKS(NAME,AUTHOR,PUBLISHER,GENRE,ISBN,YEAR) VALUES(?,?,?,?,?,?)");
        //sets each '?' from 'VALUES' to the correct values for the field (ie. inserts the book's name in the 'name' column, etc.)
        ps.setString(1,b.getName());
        ps.setString(2,b.getAuthor());
        ps.setString(3,b.getPublisher());
        ps.setString(4,b.getGenre());
        ps.setString(5,b.getISBN());
        ps.setLong(6, b.getYear());
        //updates the database to include the new book
        ps.executeUpdate();
    }
    //method which will return an array of books from the database
    public ArrayList<Book> getBooks() throws SQLException {
        //statement which will return all books from the database
        PreparedStatement ps = connection.prepareStatement("SELECT * FROM BOOKS");
        //will get the books from the database after the above statement is run
        ResultSet rs = ps.executeQuery();
        //create a new arrayList that will hold our books
        ArrayList<Book> books = new ArrayList<>();
        //while there is another book from the database, creates a new book containing the relevant fields and pushes it into the array
        while(rs.next()){
            Book temp = new Book(
                    rs.getInt(1),
                    rs.getString(2),
                    rs.getString(3),
                    rs.getString(4),
                    rs.getString(5),
                    rs.getString(6),
                    rs.getLong(7)
            );
            books.add(temp);
        }
        //returns the array of books after all books have been added
        return books;
    }
}