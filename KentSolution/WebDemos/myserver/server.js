const express =  require('express');
const app =  express();

app.use((request, response, next)=>{
    if(request.path.includes("home"))
    {
        response.write("Welcome Home");
        // response.end();
        next();
    }
    else if(request.path.includes("about"))
        {
            response.write("About us");
            response.end();
        } 
    else{
        response.write("Unknown request!")
         response.end();
    }


});

app.use((request, response, next)=>{
    response.write("XYZ");
    response.end();
});

app.listen(9999,()=>{
    console.log("server started..")
});