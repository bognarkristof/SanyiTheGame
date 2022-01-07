<?php
$servername ="localhost";
$username="root";
$password="";
$dbname="sanyiz";

//submited variables
$loginUser =$_POST["loginUser"];
$loginPass =$_POST["loginPass"];

$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error){
    die("Connection failed: ".$conn->connection_error);
}
echo "Connected to database<br>";


$sql ="SELECT password FROM user WHERE username = '".$loginUser."'";
$result = $conn->query($sql);

if($result->num_rows>0){
    while($row = $result->fetch_assoc()){
        if($row["password"] == $loginPass){
            echo "login succsess.";

            //Get player data(coin, Scoin, steps)
        }
        else{
            echo "wrong password or username";
        }
    }
} else{
    echo "no users found";
}

$conn->close();

?>



