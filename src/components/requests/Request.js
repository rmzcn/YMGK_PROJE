import axios from 'axios';

const headers = {
    Accept: 'application/json',
    'Content-Type': 'application/json; charset=utf-8',
    'Access-Control-Allow-Origin':'*'
  };

  export function post(url,data){
      return fetch(url,{
          method:"POST",
          headers,
          body:JSON.stringify(data),
      }).then(response=> response);
  }

export async function postImage(url,data){
    return await axios.post(url,data);
}

  export function get(url){
      return fetch(url,{
          method:"GET",
          headers,
      }).then(response=> response.json());
  }