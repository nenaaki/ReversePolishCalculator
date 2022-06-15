import React, { useState } from "react";
import { useRecoilState } from "recoil";
import { on } from "stream";
import {
  clearStack,
  displayStack,
  executeFormula,
  popFormula,
  pushFormula,
} from "../../Common/RPNApiCaller";
import { StackState } from "../../Store/StackAtom";
import CommonCol from "../CommonCol/CommonCol";
import PushCol from "../PushCol/PushCol";

const PushFormula: React.FC = () => {
  const SUCCESS_MESSAGE = "成功しました";

  const [, setStack] = useRecoilState(StackState);

  const [popResult, setPopResult] = useState("");
  const [clearResult, setClearResult] = useState("");
  const [runResult, setRunResult] = useState("");
  const [content, setContent] = useState<string>("");

  const onPopButtonClick = (e: React.SyntheticEvent) => {
    e.preventDefault();
    initResult();

    popFormula()
      .then(async (result) => {
        setPopResult(result);
        await updateStack();
      })
      .catch((e) => {
        setPopResult(
          `Stackからの値の取り出しに失敗しました。${(e as Error).message}`
        );
      });
  };
  const onClearButtonClick = (e: React.SyntheticEvent) => {
    e.preventDefault();
    initResult();

    clearStack()
      .then(async () => {
        setClearResult(SUCCESS_MESSAGE);
        await updateStack();
      })
      .catch((e) => {
        setClearResult(`Stackの初期化に失敗しました。${e.message}`);
      });
  };
  const onRunButtonClick = (e: React.SyntheticEvent) => {
    e.preventDefault();
    initResult();

    executeFormula()
      .then(async () => {
        setRunResult(SUCCESS_MESSAGE);
        await updateStack();
      })
      .catch((e) => {
        setRunResult(`実行に失敗しました。${e.message}`);
      });
  };

  const updateStack = async () => {
    try {
      const newStack = await displayStack();
      setStack(newStack);
    } catch (e) {
      setStack(["Stackの更新に失敗しました"]);
    }
  };

  const onPushButtonClick = (e: React.SyntheticEvent) => {
    e.preventDefault();
    pushFormula(content)
      .then(async () => {
        try {
          const newStack = await displayStack();
          setStack(newStack);
        } catch (e) {
          window.alert(
            `Stackの読み込みに失敗しました。${(e as Error).message}`
          );
        }
        setContent("");
      })
      .catch((e) => {
        window.alert(`式の送信に失敗しました。${e.message}`);
      });
  };

  const onPushInputboxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setContent(() => e.target.value);
  };

  const initResult = () => {
    setClearResult("");
    setPopResult("");
    setRunResult("");
  };

  return (
    <form onSubmit={onPushButtonClick}>
      <PushCol
        content={content}
        onInputChange={onPushInputboxChange}
        onButtonClick={onPushButtonClick}
      />
      <CommonCol
        label="Stackから取り出された値"
        buttonContent="Pop"
        onClickFunc={onPopButtonClick}
        result={popResult}
      />
      <CommonCol
        label="結果"
        buttonContent="Clear"
        onClickFunc={onClearButtonClick}
        result={clearResult}
      />
      <CommonCol
        label="実行結果"
        buttonContent="Run"
        onClickFunc={onRunButtonClick}
        result={runResult}
      />
    </form>
  );
};

export default PushFormula;
