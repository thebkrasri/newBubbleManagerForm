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

        p {
            font-size: 1.5em;
        }

        .button {
            padding: 0 20px;
            height: 35px;
            width: auto;
            line-height: 1;
            border-radius: 3px;
            font-size: 16px;
            color: black;
            background-color: rgba(191, 191, 191, 1);
            box-shadow: 0px 2px 6px 0px rgba(0,0,0,0.4);
            transition: background-color 0.3s cubic-bezier(0.4, 0, 0.2, 1), box-shadow 0.3s cubic-bezier(0.4, 0, 0.2, 1), transform 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        }

            .button:hover {
                background-color: rgba(153, 153, 153, 1);
                box-shadow: 0px 4px 6px 0px rgba(0,0,0,0.4);
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
    <input type="button" id="btnRefresh" value="Add Another Customer" class="button" />
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
<script src="Scripts/FormSubmitted.js" type="text/javascript"></script>
</html>
