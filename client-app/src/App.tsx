import React, { useEffect, useState } from "react";
import axios from "axios";

function App() {
  const [tasks, setTask] = useState([]);
  useEffect(() => {
    axios.get("http://localhost:5000/api/tasks").then((response) => {
      console.log(response);
      setTask(response.data);
    });
  }, []);
  return (
    <div className="App">
      <ul className="font-bold text-3xl  text-center rounded-sm py-8 px-8 shadow-lg">
        {tasks.map((task: any) => (
          <li key={task.id}>{task.title}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
