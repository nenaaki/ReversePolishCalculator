import React from "react";
import "./App.css";
import Content from "./Component/Content/Content";
import Header from "./Component/Header/Header";

const App: React.FC = () => {
  return (
    <div className="App">
      <Header />
      <Content />
    </div>
  );
};

export default App;
