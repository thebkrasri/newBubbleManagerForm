<%@ Page Title="Bubble Manager" Language="C#" AutoEventWireup="true" CodeFile="FormSubmitted.aspx.cs" Inherits="FormSubmitted" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Raleway" />

    <style>
        body {
            text-align: center;
            font-family: 'Raleway';
            margin: auto;
            height: 100%;
            width: 100%
        }

        img {
            margin: auto;
            padding-right: 10px;
            vertical-align: middle;
            max-height: 100px;
            max-width: 75%;
            margin: auto;
        }
        p{
            font-size: 1.5em;
        }
    </style>

    <title>Bubble Manager</title>
</head>

<body runat="server" id="pagebody">
    <img src="Content/logo.png" alt="Welcome to Bubble Manager!" />
    <h1>Thank you!</h1>
    <p>
        Your information has been uploaded to our database.<br />
        You are one step closer to the underwater world!
    </p>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
<script src="Scripts/FormSubmitted.js" type="text/javascript"></script>
</html>
