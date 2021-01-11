# db_products_table_with_colors-and-sizes
A hypothetical store has products that are to be sold, for instance the store has golf t-shirts, and this golf t-shirts vary in terms of color and size, so if there are 7 different colors, and each of this colors come in different sizes(XS,S,M,L,XL,XXL). what is the best way to structure the database table so that we can know which color and size of the t-shirt we want to sell, or deduct from.
First solution - Create 3 tables, A product table, colors tables and sizes table
Second solution - use one table, add color and size fields
Third solution - use one table, but have one field that stores a json of the colors, sizes and quantity relatively
If you have a better solution or an improvement, don't hesitate to make Pull Requests :)
