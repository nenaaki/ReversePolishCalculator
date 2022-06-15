import React from "react";
import { Card, ListGroup } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { displayStack } from "../../Common/RPNApiCaller";
import { StackState } from "../../Store/StackAtom";
import "./Stack.css";

const Stack = () => {
  const [stack, setStack] = useRecoilState(StackState);

  React.useEffect(() => {
    displayStack().then((result) => {
      setStack(result);
    });
  }, []);

  return (
    <Card className="stack-container">
      <Card.Header>Stackの状態</Card.Header>
      <ListGroup>
        {stack?.map((item, key) => (
          <ListGroup.Item key={key}>{item}</ListGroup.Item>
        ))}
      </ListGroup>
    </Card>
  );
};

export default Stack;
