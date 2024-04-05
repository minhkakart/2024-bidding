namespace WebApi.Helpers;

using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

public class DataContext
{
    private DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = $"Server={_dbSettings.Server}; Database={_dbSettings.Database}; Uid={_dbSettings.UserId}; Pwd={_dbSettings.Password};";
        return new MySqlConnection(connectionString);
    }

    public async Task Init()
    {
        await _initDatabase();
        await _initTables();
    }

    private async Task _initDatabase()
    {
        // create database if it doesn't exist
        var connectionString = $"Server={_dbSettings.Server}; Uid={_dbSettings.UserId}; Pwd={_dbSettings.Password};";
        using var connection = new MySqlConnection(connectionString);
        var sql = $"CREATE DATABASE IF NOT EXISTS `{_dbSettings.Database}`;";
        await connection.ExecuteAsync(sql);
    }

    private async Task _initTables()
    {
        // create tables if they don't exist
        using var connection = CreateConnection();
        await _initUserGroup();
        await _initUsers();
        await _initUserProfile();
        await _initAuthor();
        await _initCategory();
        await _initProduct();
        await _initProductImage();
        await _initOrder();
        await _initOrderDetail();
        await _initTag();
        await _initProductTag();


        async Task _initUsers()
        {
            /*var sql = """
                CREATE TABLE IF NOT EXISTS Users (
                    Id INT NOT NULL AUTO_INCREMENT,
                    Title VARCHAR(255),
                    FirstName VARCHAR(255),
                    LastName VARCHAR(255),
                    Email VARCHAR(255),
                    Role INT,s
                    PasswordHash VARCHAR(255),
                    PRIMARY KEY (Id)
                );
            """;*/
            var sql = """
                CREATE TABLE IF NOT EXISTS User (
                    user_id INT NOT NULL AUTO_INCREMENT,
                    group_id INT,
                    username VARCHAR(255),
                    password VARCHAR(255),
                    PRIMARY KEY (user_id),
                    FOREIGN KEY (group_id) REFERENCES UserGroup(group_id) ON DELETE CASCADE
                )
                """;
            await connection.ExecuteAsync(sql);
        }

        // Add more tables here
        
        async Task _initUserProfile()
        {
			var sql = """
				CREATE TABLE IF NOT EXISTS UserProfile (
					profile_id INT NOT NULL AUTO_INCREMENT,
					user_id VARCHAR(255),
					fullname VARCHAR(255),
					phone VARCHAR(255),
					email VARCHAR(255),
					address VARCHAR(255),
					PRIMARY KEY (profile_id), FOREIGN KEY (user_id) REFERENCES aspnetusers(Id) ON DELETE CASCADE
				);
			""";
			await connection.ExecuteAsync(sql);
		}

        async Task _initUserGroup()
        {
            var sql = """
				CREATE TABLE IF NOT EXISTS UserGroup (
					group_id INT NOT NULL AUTO_INCREMENT,
					group_name VARCHAR(255),
					PRIMARY KEY (group_id)
				);
			""";
            await connection.ExecuteAsync(sql);
        }

		async Task _initAuthor()
		{
			var sql = """
				CREATE TABLE IF NOT EXISTS Author (
					author_id INT NOT NULL AUTO_INCREMENT,
					author_name VARCHAR(255),
					PRIMARY KEY (author_id)
				);
			""";
			await connection.ExecuteAsync(sql);
		}

		async Task _initCategory()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS Category (
                category_id INT NOT NULL AUTO_INCREMENT,
                category_name VARCHAR(255),
                PRIMARY KEY (category_id)
                );
                """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initProduct()
        {
			var sql = """
				CREATE TABLE IF NOT EXISTS Product (
				product_id INT NOT NULL AUTO_INCREMENT,
				category_id INT,
				author_id INT,
				product_name VARCHAR(255),
				price DECIMAL(10, 2), description TEXT,
				PRIMARY KEY (product_id),
				FOREIGN KEY (category_id) REFERENCES Category(category_id) ON DELETE CASCADE,
				FOREIGN KEY (author_id) REFERENCES Author(author_id) ON DELETE CASCADE
				);
				""";
			await connection.ExecuteAsync(sql);
		}

        async Task _initProductImage()
        {
            var sql = """
				CREATE TABLE IF NOT EXISTS ProductImage (
				image_id INT NOT NULL AUTO_INCREMENT,
				product_id INT,
				image_url VARCHAR(255),
				PRIMARY KEY (image_id),
				FOREIGN KEY (product_id) REFERENCES Product(product_id) ON DELETE CASCADE
				);
				""";
            await connection.ExecuteAsync(sql);
        }

        async Task _initOrder()
        {
			var sql = """
				CREATE TABLE IF NOT EXISTS Orders (
				order_id INT NOT NULL AUTO_INCREMENT,
				user_id varchar(255),
				order_date DATETIME,
				PRIMARY KEY (order_id),
				FOREIGN KEY (user_id) REFERENCES aspnetusers(Id) ON DELETE CASCADE
				);
				""";
			await connection.ExecuteAsync(sql);
		}

        async Task _initOrderDetail()
        {
            var sql = """
				CREATE TABLE IF NOT EXISTS OrderDetail (
				order_detail_id INT NOT NULL AUTO_INCREMENT,
				product_id INT,
				order_id INT,
				PRIMARY KEY (order_detail_id),
				FOREIGN KEY (order_id) REFERENCES Orders(order_id) ON DELETE CASCADE,
				FOREIGN KEY (product_id) REFERENCES Product(product_id) ON DELETE CASCADE
				);
				""";
            await connection.ExecuteAsync(sql);
        }

        async Task _initTag()
        {
			var sql = """
                CREATE TABLE IF NOT EXISTS Tag (
                tag_id INT NOT NULL AUTO_INCREMENT,
                tag_name VARCHAR(255),
                PRIMARY KEY (tag_id)
                );
                """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initProductTag()
        {
			var sql = """
				CREATE TABLE IF NOT EXISTS ProductTag (
				product_tag_id INT NOT NULL AUTO_INCREMENT,
				tag_id INT,
				product_id INT,
				PRIMARY KEY (product_tag_id),
				FOREIGN KEY (product_id) REFERENCES Product(product_id) ON DELETE CASCADE,
				FOREIGN KEY (tag_id) REFERENCES Tag(tag_id) ON DELETE CASCADE
				);
				""";
			await connection.ExecuteAsync(sql);
		}

    }
}