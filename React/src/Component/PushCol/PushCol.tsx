import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./PushCol.css";

const PushCol = () => {
  const [content, setContent] = useState<string>("");

  return (
    <Form.Group className="push-col-container">
      <div>
        <Form.Label className="fs-6 mb-0">Stackに送る式</Form.Label>
        <Form.Control
          type="text"
          value={content}
          onChange={(e) => setContent(e.target.value)}
        />
      </div>
      <Button className="push-button">Push</Button>
    </Form.Group>
  );
};

export default PushCol;
