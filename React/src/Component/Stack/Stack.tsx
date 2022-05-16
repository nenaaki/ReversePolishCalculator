import React from "react";
import { useState } from "react";
import { Card, ListGroup } from "react-bootstrap";
import "./Stack.css";

const Stack = () => {
  const [stack, setStack] = useState<string[]>();

  React.useEffect(() => {
    setStack(["test1", "test2", "test3"]);
  }, []);

  return (
    <Card className="stack-container">
      <Card.Header>Stackの状態</Card.Header>
      <ListGroup>
        {stack?.map((item) => (
          <ListGroup.Item>{item}</ListGroup.Item>
        ))}
      </ListGroup>
    </Card>
  );
};

export default Stack;
