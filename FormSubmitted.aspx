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
            margin: 20px auto;
            padding-right: 10px;
            vertical-align: middle;
            max-height: 200px;
            max-width: 75%;
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

        #redirectDiv div {
            width: auto;
            display: inline-block;
            margin-top: 10px;
            font-size: 1.2em;
        }

        .dot {
            display: inline;
            margin: 0 0.1em;
            position: relative;
            font-size: 2em;
            font-family: "Roboto", "Open Sans", sans-serif;
            opacity: 0;
            animation: showHideDot 2.5s ease-in-out infinite;
        }

            .dot.one {
                animation-delay: 0.2s;
            }

            .dot.two {
                animation-delay: 0.4s;
            }

            .dot.three {
                animation-delay: 0.6s;
            }

        @keyframes showHideDot {
            0% {
                opacity: 0;
            }

            50% {
                opacity: 1;
            }

            60% {
                opacity: 1;
            }

            100% {
                opacity: 0;
            }
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
    <p id="CustomerID" style="display:none">Your customer ID is <span id="IDnum" style="font-weight: bold"></span></p>
    <input type="button" id="btnRefresh" value="Add Another Customer" class="button" />
    <div id="redirectDiv" style="display: none">
        <div>
            <span>Redirecting back to registration form</span>
        </div>
        <div>
            <span class="dot one">.</span>
            <span class="dot two">.</span>
            <span class="dot three">.</span>
        </div>
    </div>
    
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
<script src="Scripts/FormSubmitted.js" type="text/javascript"></script>
</html>
