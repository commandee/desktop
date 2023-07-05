
string host = 'aws.connect.psdb.cloud';
string user = 'jv83hmjvu529auooy88s';
string password = 'pscale_pw_uzNGOGAOwGanuDsZTWYgw3AdWriNnbUhZKWjcRX5eRt';
string database = 'commandee';

var settings = new ConnectionSettings(
  host: host, 
  port: 3306,
  user: user,
  password: password,
  db: database
);
var conn = await MySqlConnection.connect(settings);

