var connect = new signalR.HubConnectionBuilder().WithUrl("/chathub").build();
// Get All Notifaction For User;





connect.start();
// Send Notifcation to another User