<?php
$servername ="localhost";
$username="root";
$password="";
$dbname="sanyiz";

$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error){
    die("Connection failed: ".$conn->connection_error);
}
echo "Connected to database<br>";

$sql ="SELECT id,username,email FROM user";
$result = $conn->query($sql);

if($result->num_rows>0){
    while($row = $result->fetch_assoc()){
        echo "id: ".$row["id"]."-Name: ".$row["username"]."email: ".$row["email"]."<br>";
    }
} else{
    echo "no users found";
}

$conn->close();
?>