   function Fetch(method, url) {
        return new Promise((resolve, reject) => {
          var helper = new XMLHttpRequest();
          helper.onreadystatechange = () => {
            if (helper.readyState == 4 && helper.status == 200) {
              var data = JSON.parse(helper.responseText);
              resolve(data);
            }
            //else .. call to reject
          };
          helper.open(method, url);
          helper.send();
        });
      }
