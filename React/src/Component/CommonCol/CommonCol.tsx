import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { CommonColProps } from "./interface";
import "./CommonCol.css";

const CommonCol: React.FC<CommonColProps> = (props) => {
  const [result, setResult] = useState<string>("");

  return (
    <Form.Group className="common-col-container">
      <Button className="common-button">{props.buttonContent}</Button>
      <div>
        <Form.Label className="fs-6 mb-0">{props.label}</Form.Label>
        <div className="border border-secondary command-result">{result}</div>
      </div>
    </Form.Group>
  );
};

export default CommonCol;
