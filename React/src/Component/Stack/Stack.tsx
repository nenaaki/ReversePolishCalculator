import React from "react";
import { useState } from "react";
import { Card, ListGroup } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { StackState } from "../../Store/StackAtom";
import "./Stack.css";

const Stack = () => {
  // const [stack, setStack] = useState<string[]>();
  const [stack, setStack] = useRecoilState(StackState);

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
