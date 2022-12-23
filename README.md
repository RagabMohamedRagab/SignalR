## Basic of SignalR
> SignalR is library which enable realtime between client and server.
<br/>
<img src="Help/Request.PNG" alt="" style="width:50%;height:300px" />
<p>SignalR dependency on request send from clinet to server to response at the same second</p>

## SignalR can be useful where :

<ul>
 <li>Gaming</li>
 <li>Social Network</li>
 <li>Voting</li>
 <li>GPS</li>
 <li>Maps</li>
 <li>Dashboards</li>
 <li>Travel Alerts</li>
 <li>Meeting App</li>
 </ul>

## RealTime Communication :

>SignalR Supports following Techniques for handling realtime.

<ul>
 <li>WebScoket</li>
 <li> Server Send Event</li>
 <li>logg Polling</li>
 </ul>

## Hubs 
> SignalR used Hubs to Communication Between Client And Server.

<img src="Help/slide_1.jpg" alt="" style="width:50%;height:300px"/>

## Install SignalR in Asp.net core 6

<ol>
 <li>In Solution Explorer, right-click the project, and select Add > Client-Side Library.</li>
 <li>In the Add Client-Side Library dialog:
   <ul>
     <li>Select <b>unpkg</b> for Provider</li>
     <li>Enter <mark>@microsoft/signalr@latest</mark> for Library</li>
     <li>Select <b> Choose specific files</b>, expand the <i>dist/browser</i> folder, and select<mark>signalr.js and signalr.min.js.</mark></li>
     <li>Set Target Location to <i>wwwroot/js/signalr</i>/</li>
     <li><b>Select Install</b></li>
     </ul>
     </li>
     <li> <img src="Help/CSL.PNG" alt="" style="width:50%;height:300px"/></li>
     </ol>
     
     
     

