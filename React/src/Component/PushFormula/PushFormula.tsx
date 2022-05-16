import { Button, Form } from "react-bootstrap";
import CommonCol from "../CommonCol/CommonCol";
import PushCol from "../PushCol/PushCol";

const PushFormula: React.FC = () => {
  return (
    <form>
      <PushCol />
      <CommonCol label="Stackから取り出される値" buttonContent="Pop" />
      <CommonCol label="結果" buttonContent="Clear" />
      <CommonCol label="実行結果" buttonContent="Run" />
    </form>
  );
};

export default PushFormula;
